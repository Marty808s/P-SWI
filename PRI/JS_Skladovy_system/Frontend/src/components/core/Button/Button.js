import React from "react";
import Paragraph from "@components/core/Text/Paragraph";
import { FiBook, FiEdit, FiSearch, FiFilter, FiPlus, FiEye, FiEyeOff, FiSettings } from "react-icons/fi";
import { TbUsers } from "react-icons/tb";
import { RxCross1, RxCheck } from "react-icons/rx";
import { FaAngleDown, FaAngleUp, FaRegFileAlt, FaLock, FaUser, FaArrowLeft, FaSave, FaDownload, FaUpload, FaCalendarAlt } from "react-icons/fa";
import { MdOutlineManageAccounts, MdPersonOutline  } from "react-icons/md";

export default function Button({id, children, text, property, onClick, textSize = "base", hover=true ,pointer = true, variant = "blue", buttonSize = "big", noVariant = false, icon = null, iconSize = "14", iconColor = "text-white", disabled = false, type = "button" }) {

    const baseClassBig = "px-4 py-2 rounded-lg transition-colors duration-200";
    const baseClassSmall = "px-2 py-1 rounded-lg transition-colors duration-200";

    const icons = {
        angleDown: <FaAngleDown size={iconSize} className={iconColor} />,
        angleUp: <FaAngleUp size={iconSize} className={iconColor} />,
        book: <FiBook size={iconSize} className={iconColor} />,
        edit: <FiEdit size={iconSize} className={iconColor} />,
        search: <FiSearch size={iconSize} className={iconColor} />,
        filter: <FiFilter size={iconSize} className={iconColor} />,
        plus: <FiPlus size={iconSize} className={iconColor} />,
        cross: <RxCross1 size={iconSize} className={iconColor} />,
        check: <RxCheck size={iconSize} className={iconColor} />,
        users: <TbUsers size={iconSize} className={iconColor} />,
        user: <MdPersonOutline  size={iconSize} className={iconColor} />,
        eye: <FiEye size={iconSize} className={iconColor} />,
        arrowLeft: <FaArrowLeft  size={iconSize} className={iconColor} />,
        "eye-slash": <FiEyeOff size={iconSize} className={iconColor} />,
        lock: <FaLock size={iconSize} className={iconColor} />,
        download: <FaDownload size={iconSize} className={iconColor} />,
        gear: <FiSettings size={iconSize} className={iconColor} />,
        calendar: <FaCalendarAlt size={iconSize} className={iconColor} />,
        upload: <FaUpload size={iconSize} className={iconColor} />,
        save: <FaSave  size={iconSize} className={iconColor} />,
        manage: <MdOutlineManageAccounts size={iconSize} className={iconColor} />,
        doc: <FaRegFileAlt size={"14"} className={iconColor} />


    }

    const baseIconLayout = "inline-flex items-center gap-1"
    
    const baseText = text ? <Paragraph variant={textSize}>{text}</Paragraph> : null;
    
    const variants = {
        blue: "bg-blue-300 text-white " + baseClassBig,
        red: "bg-red-400 text-white " + baseClassBig,
        yellow: "bg-yellow-300 text-white " + baseClassBig,
        green: "bg-green-300 text-white " + baseClassBig,
        gray: "bg-gray-300 text-white " + baseClassBig,
        primarySmall: "bg-facultyCol text-white " + baseClassSmall,
        blueSmall: "bg-blue-300 text-white " + baseClassSmall,
        redSmall: "bg-red-400 text-white " + baseClassSmall,
        yellowSmall: "bg-yellow-300 text-white " + baseClassSmall,
        greenSmall: "bg-green-300 text-white " + baseClassSmall,
        graySmall: "bg-gray-300 text-white " + baseClassSmall,
    };

    return (

        <button
            id={id}
            className={`
                ${noVariant ? "" : variants[variant]} 
                ${!noVariant && (buttonSize === "big" ? baseClassBig : baseClassSmall)} 
                ${hover ? "hover:bg-gray-400" : ""}
                ${property || ''} 
                ${!disabled ? (pointer ? "cursor-pointer" : "cursor-default") : ("opacity-50 cursor-not-allowed")}

                ${icon && baseIconLayout}
            `}
            onClick={onClick}
            type={type}
        >
            {icon && icons[icon]}
            {baseText || children}
        </button>
    );
}